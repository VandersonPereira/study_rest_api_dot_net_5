using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Calculadora.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculadoraController : ControllerBase
    {
        private readonly ILogger<CalculadoraController> _logger;

        public CalculadoraController(ILogger<CalculadoraController> logger)
        {
            _logger = logger;
        }

        [HttpGet("somar/{primeiroNumero}/{segundoNumero}")]
        public IActionResult Somar(string primeiroNumero, string segundoNumero)
        {
            if (EstaEmFormatoNumerico(primeiroNumero) && EstaEmFormatoNumerico(segundoNumero))
            {
                var soma = ConverterParaDecimal(primeiroNumero) + ConverterParaDecimal(segundoNumero);
                return Ok($"A soma é : {soma}");
            }

            return BadRequest("Entrada Inválida");
        }

        [HttpGet("subtrair/{primeiroNumero}/{segundoNumero}")]
        public IActionResult Subtrair(string primeiroNumero, string segundoNumero)
        {
            if (EstaEmFormatoNumerico(primeiroNumero) && EstaEmFormatoNumerico(segundoNumero))
            {
                var subtracao = ConverterParaDecimal(primeiroNumero) - ConverterParaDecimal(segundoNumero);
                return Ok($"A subtração é : {subtracao}");
            }

            return BadRequest("Entrada Inválida");
        }

        [HttpGet("dividir/{primeiroNumero}/{segundoNumero}")]
        public IActionResult Dividir(string primeiroNumero, string segundoNumero)
        {
            if (EstaEmFormatoNumerico(primeiroNumero) && EstaEmFormatoNumerico(segundoNumero) && ConverterParaDecimal(segundoNumero) != 0)
            {
                var divisao = ConverterParaDecimal(primeiroNumero) / ConverterParaDecimal(segundoNumero);
                return Ok($"A divisão é : {divisao}");
            }

            return BadRequest("Entrada Inválida");
        }

        [HttpGet("multiplicar/{primeiroNumero}/{segundoNumero}")]
        public IActionResult Multiplicar(string primeiroNumero, string segundoNumero)
        {
            if (EstaEmFormatoNumerico(primeiroNumero) && EstaEmFormatoNumerico(segundoNumero))
            {
                var multiplicacao = ConverterParaDecimal(primeiroNumero) * ConverterParaDecimal(segundoNumero);
                return Ok($"A multiplicação é : {multiplicacao}");
            }

            return BadRequest("Entrada Inválida");
        }

        [HttpGet("raiz_quadrada/{numero}")]
        public IActionResult ExtrairRaizQuadrada(string numero)
        {
            if (EstaEmFormatoNumerico(numero))
            {
                var raizQuadrada = Math.Sqrt(ConverterParaDouble(numero));
                return Ok($"A raiz quadrada é : {raizQuadrada}");
            }

            return BadRequest("Entrada Inválida");
        }

        [HttpGet("potencia/{primeiroNumero}/{segundoNumero}")]
        public IActionResult CalcularPotencializacao(string primeiroNumero, string segundoNumero)
        {
            if (EstaEmFormatoNumerico(primeiroNumero) && EstaEmFormatoNumerico(segundoNumero))
            {
                var potencializacao = Math.Pow(ConverterParaDouble(primeiroNumero), ConverterParaDouble(segundoNumero));
                return Ok($"A potência de {primeiroNumero} elevado a {segundoNumero} é : {potencializacao}");
            }

            return BadRequest("Entrada Inválida");
        }

        private decimal ConverterParaDecimal(string numeroEmTexto)
        {
            if (decimal.TryParse(numeroEmTexto, out decimal valorDecimal))
                return valorDecimal;

            return 0;
        }

        private double ConverterParaDouble(string numeroEmTexto)
        {
            if (double.TryParse(numeroEmTexto, out double valorDouble))
                return valorDouble;

            return 0;
        }

        private bool EstaEmFormatoNumerico(string numeroEmTexto) => decimal.TryParse(numeroEmTexto, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out decimal numeroDecimal);
    }
}
