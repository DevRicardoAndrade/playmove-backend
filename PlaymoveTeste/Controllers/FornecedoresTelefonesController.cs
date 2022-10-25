using Microsoft.AspNetCore.Mvc;
using PlaymoveTeste.Model;
using PlaymoveTeste.Repositorie;

namespace PlaymoveTeste.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FornecedoresTelefonesController : ControllerBase
    {
        //Injecao de dependencia
        private readonly IFornecedoresTelefonesRepositorie? _fornecedoresTelefones;
        public FornecedoresTelefonesController(IFornecedoresTelefonesRepositorie fornecedoresTelefones)
        {
            _fornecedoresTelefones = fornecedoresTelefones;
        }
        //EndPoints
        [HttpGet]
        public ActionResult<IEnumerable<FornecedoresTelefonesModel>> Get()
        {
            try
            {
                return _fornecedoresTelefones.GetAll();
            }
            catch (Exception ex)
            {
                return NotFound($"ERROR: {ex.Message}");
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<FornecedoresTelefonesModel> Get(int id)
        {
            try
            {
                if (id > 0)
                    return _fornecedoresTelefones.GetById(id);
                else
                    return NotFound("Id passado é 0");
            }
            catch (Exception ex)
            {
                return NotFound($"ERROR: {ex.Message}");
            }
        }
        [HttpPost]
        public ActionResult<FornecedoresTelefonesModel> Post(FornecedoresTelefonesModel model)
        {
            try
            {
                if (model != null)
                    return _fornecedoresTelefones.Insert(model);
                else
                    return NotFound("Model inválido");
            }
            catch (Exception ex)
            {
                return NotFound($"ERROR: {ex.Message}");
            }
        }
        [HttpPut("{id:int}")]
        public ActionResult<FornecedoresTelefonesModel> Put(int id, [FromBody] FornecedoresTelefonesModel model)
        {
            try
            {
                if (id > 0)
                    return _fornecedoresTelefones.Update(id, model);
                else
                    return NotFound("Id passado é 0");
            }
            catch (Exception ex)
            {
                return NotFound($"ERROR: {ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<FornecedoresTelefonesModel> Delete(int id)
        {
            try
            {
                if (id > 0)
                    return _fornecedoresTelefones.Delete(id);
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
