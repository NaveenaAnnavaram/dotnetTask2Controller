using Microsoft.AspNetCore.Mvc;
using System;
using LocalMath = System.Math;

namespace dotnetTaskTwo2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MathController : ControllerBase
    {
        private readonly IMath _math;

        public MathController(IMath math)
        {
            _math = math;
        }

        [HttpGet("add")]
        public IActionResult Add([FromQuery] double a, [FromQuery] double b)
        {
            double result = _math.Add(a, b);
            return Ok(result);
        }

        [HttpGet("subtract")]
        public IActionResult Subtract([FromQuery] double a, [FromQuery] double b)
        {
            double result = _math.Subtract(a, b);
            return Ok(result);
        }

        [HttpGet("multiply")]
        public IActionResult Multiply([FromQuery] double a, [FromQuery] double b)
        {
            double result = _math.Multiply(a, b);
            return Ok(result);
        }

        [HttpGet("divide")]
        public IActionResult Divide([FromQuery] double a, [FromQuery] double b)
        {
            try
            {
                double result = _math.Divide(a, b);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("simpleinterest")]
        public IActionResult SimpleInterest([FromQuery] double principal, [FromQuery] double rate, [FromQuery] double time)
        {
            double simpleInterest = (principal * rate * time) / 100;
            return Ok(simpleInterest);
        }

        [HttpGet("compoundinterest")]
        public IActionResult CompoundInterest([FromQuery] double principal, [FromQuery] double rate, [FromQuery] double time)
        {
            double compoundInterest = principal * LocalMath.Pow(1 + rate / 100, time) - principal;
            return Ok(compoundInterest);
        }

    }
}
