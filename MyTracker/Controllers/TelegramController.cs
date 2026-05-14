using LogicaAplicacion.CasosDeUso;
using LogicaNegocio.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MyTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelegramController : ControllerBase
    {
        private readonly ITelegramBotClient _botClient;
        private readonly AltaGasto _altaGasto;
        private readonly AltaCategoria _altaCategoria;
        private readonly ListarGasto _listarGastos;
        private readonly ListarCategoria _listarCategorias;

        public TelegramController(ITelegramBotClient botClient,
                                  AltaGasto altaGasto,
                                  AltaCategoria altaCategoria,
                                  ListarGasto listarGastos,
                                  ListarCategoria listarCategorias)
        {
            _botClient = botClient;
            _altaGasto = altaGasto;
            _altaCategoria = altaCategoria;
            _listarGastos = listarGastos;
            _listarCategorias = listarCategorias;
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] Update update)
        {
            if (update.Message?.Text == null) return Ok();

            var chatId = update.Message.Chat.Id;
            var texto = update.Message.Text.Trim();

            try
            {
                // /categorias
                if (texto == "/categorias")
                {
                    var categorias = _listarCategorias.Execute();

                    if (!categorias.Any())
                    {
                        await _botClient.SendMessage(chatId, "No tenés categorías registradas.");
                        return Ok();
                    }

                    var respuesta = string.Join("\n", categorias.Select(c => $"• {c.Nombre}"));
                    await _botClient.SendMessage(chatId, "📋 Categorías:\n" + respuesta);
                }

                // /nuevacategoria Comida
                else if (texto.StartsWith("/nuevacategoria"))
                {
                    var nombre = texto.Replace("/nuevacategoria", "").Trim();

                    if (string.IsNullOrEmpty(nombre))
                    {
                        await _botClient.SendMessage(chatId, "❌ Uso correcto: /nuevacategoria [nombre]");
                        return Ok();
                    }

                    _altaCategoria.Execute(new AltaCategoriaDTO { Nombre = nombre });
                    await _botClient.SendMessage(chatId, $"✅ Categoría '{nombre}' creada.");
                }

                // /gasto 500 Comida almuerzo
                else if (texto.StartsWith("/gasto"))
                {
                    var partes = texto.Split(' ');

                    if (partes.Length < 4)
                    {
                        await _botClient.SendMessage(chatId, "❌ Uso correcto: /gasto [precio] [categoria] [descripcion]");
                        return Ok();
                    }

                    if (!int.TryParse(partes[1], out int precio))
                    {
                        await _botClient.SendMessage(chatId, "❌ El precio debe ser un número entero.");
                        return Ok();
                    }

                    var nombreCategoria = partes[2];
                    var descripcion = string.Join(" ", partes.Skip(3));

                    var categorias = _listarCategorias.Execute();
                    var cat = categorias.FirstOrDefault(c =>
                        c.Nombre.ToLower() == nombreCategoria.ToLower());

                    if (cat == null)
                    {
                        await _botClient.SendMessage(chatId, $"❌ No existe la categoría '{nombreCategoria}'.\nUsá /categorias para ver las disponibles.");
                        return Ok();
                    }

                    _altaGasto.Execute(new AltaGastoDTO
                    {
                        Precio = precio,
                        CategoriaId = cat.Id,
                        Descripcion = descripcion
                    });

                    await _botClient.SendMessage(chatId, $"✅ Gasto de ${precio} en '{nombreCategoria}' registrado.");
                }

                // /listar
                else if (texto == "/listar")
                {
                    var gastos = _listarGastos.Execute();

                    if (!gastos.Any())
                    {
                        await _botClient.SendMessage(chatId, "No tenés gastos registrados.");
                        return Ok();
                    }

                    var respuesta = string.Join("\n", gastos.Select(g =>
                        $"• {g.Descripcion} - ${g.Precio} ({g.NombreCategoria}) - {g.Fecha:dd/MM/yyyy}"));

                    await _botClient.SendMessage(chatId, "💸 Gastos:\n" + respuesta);
                }

                // /resumen
                else if (texto == "/resumen")
                {
                    var gastos = _listarGastos.Execute();

                    if (!gastos.Any())
                    {
                        await _botClient.SendMessage(chatId, "No tenés gastos registrados.");
                        return Ok();
                    }

                    var resumen = gastos
                        .GroupBy(g => g.NombreCategoria)
                        .Select(g => $"• {g.Key}: ${g.Sum(x => x.Precio)}");

                    var total = gastos.Sum(g => g.Precio);
                    var respuesta = "📊 Resumen por categoría:\n" +
                                    string.Join("\n", resumen) +
                                    $"\n\n💰 Total: ${total}";

                    await _botClient.SendMessage(chatId, respuesta);
                }

                // Comando no reconocido
                else
                {
                    await _botClient.SendMessage(chatId,
                        "🤖 Comandos disponibles:\n" +
                        "/categorias - Ver categorías\n" +
                        "/nuevacategoria [nombre] - Crear categoría\n" +
                        "/gasto [precio] [categoria] [descripcion] - Registrar gasto\n" +
                        "/listar - Ver todos los gastos\n" +
                        "/resumen - Ver total por categoría");
                }
            }
            catch (Exception ex)
            {
                await _botClient.SendMessage(chatId, $"❌ Error: {ex.Message}");
            }

            return Ok();
        }
    }
}

