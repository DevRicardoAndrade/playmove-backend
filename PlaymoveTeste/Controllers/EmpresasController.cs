using Microsoft.AspNetCore.Mvc;
using PlaymoveTeste.DataContext;
using PlaymoveTeste.Model;
using PlaymoveTeste.Repositorie;
using System.Text.Json;

namespace PlaymoveTeste.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        //Injecao de dependencia
        private readonly IEmpresasRepositorie? _empresas;
        public EmpresasController(IEmpresasRepositorie empresas)
        {
            _empresas = empresas;
        }
        //EndPoints
        [HttpGet]
        public ActionResult<IEnumerable<EmpresasModel>> Get()
        {
            try
            {
                return _empresas.GetAll();
            }
            catch (Exception ex)
            {
                return NotFound($"ERROR: {ex.Message}");
            }
        }
        [HttpGet("/EmpresasFornecedores" )]
        public ActionResult<IEnumerable<EmpresasModel>> GetEmpresasFornecedores()
        {
            try
            {
                return _empresas.GetEmpresaForneceores();
            }
            catch (Exception ex)
            {
                return NotFound($"ERROR: {ex.Message}");
            }
        }
        [HttpGet("/EmpresasFornecedores/{id:int}")]
        public ActionResult<EmpresasModel> GetEmpresasFornecedores(int id)
        {
            try
            {
                return _empresas.GetEmpresaForneceoresById(id);
            }
            catch (Exception ex)
            {
                return NotFound($"ERROR: {ex.Message}");
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<EmpresasModel> Get(int id)
        {
            try
            {
                if (id > 0)
                    return _empresas.GetById(id);
                else
                    return NotFound("Id passado é 0");
            }
            catch (Exception ex)
            {
                return NotFound($"ERROR: {ex.Message}");
            }
        }
        [HttpPost]
        public ActionResult<EmpresasModel> Post(EmpresasModel model)
        {
            try
            {
                if (model != null)
                    return _empresas.Insert(model);
                else
                    return NotFound("Model inválido");
            }
            catch (Exception ex)
            {
                return NotFound($"ERROR: {ex.Message}");
            }
        }
        [HttpPut("{id:int}")]
        public ActionResult<EmpresasModel> Put(int id, [FromBody]EmpresasModel model)
        {
            try
            {
                if (id > 0)
                    return _empresas.Update(id, model);
                else
                    return NotFound("Id passado é 0");
            }
            catch (Exception ex)
            {
                return NotFound($"ERROR: {ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<EmpresasModel> Delete(int id)
        {
            try
            {
                if (id > 0)
                    return _empresas.Delete(id);
                else
                    return NotFound("Id passado é 0");
            }
            catch (Exception ex)
            {
                return NotFound($"ERROR: {ex.Message}");
            }
        }

    }
}
