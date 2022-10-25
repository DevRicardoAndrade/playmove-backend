using Microsoft.AspNetCore.Mvc;
using PlaymoveTeste.DataContext;
using PlaymoveTeste.Model;
using PlaymoveTeste.Repositorie;
using System.Text.Json;

namespace PlaymoveTeste.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
       
        //Injecao de dependencia
        private readonly IFornecedoresRepositorie? _fornecedores;
        public FornecedoresController(IFornecedoresRepositorie fornecedores)
        {
            _fornecedores = fornecedores;
        }
        //EndPoints
        [HttpGet("/Fornecedores")]
        public ActionResult<IEnumerable<FornecedoresModel>> Get()
        {
            try
            {
                return _fornecedores.GetAll();
            }
            catch (Exception ex)
            {
                return NotFound($"ERROR: {ex.Message}");
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<FornecedoresModel> Get(int id)
        {
            try
            {
                if (id > 0)
                    return _fornecedores.GetById(id);
                else
                    return NotFound("Id passado é 0");
            }
            catch (Exception ex)
            {
                return NotFound($"ERROR: {ex.Message}");
            }
        }
        [HttpPost]
        public ActionResult<FornecedoresModel> Post(FornecedoresModel model)
        {
            try
            {
                if (model != null)
                    return _fornecedores.Insert(model);
                else
                    return NotFound("Model inválido");
            }
            catch (Exception ex)
            {
                return NotFound($"ERROR: {ex.Message}");
            }
        }
        [HttpPut("{id:int}")]
        public ActionResult<FornecedoresModel> Put(int id, [FromBody] FornecedoresModel model)
        {
            try
            {
                if (id > 0)
                    return _fornecedores.Update(id, model);
                else
                    return NotFound("Id passado é 0");
            }
            catch (Exception ex)
            {
                return NotFound($"ERROR: {ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<FornecedoresModel> Delete(int id)
        {
            try
            {
                if (id > 0)
                    return _fornecedores.Delete(id);
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
