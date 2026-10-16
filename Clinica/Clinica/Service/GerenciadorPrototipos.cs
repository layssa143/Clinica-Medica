using Clinica.Models;

namespace Clinica.Service
{
    public class GerenciadorPrototipos
    {
        private readonly Dictionary<
            string,
            PacoteExame
        > _prototipos = new();

        public void CadastrarPrototipo(
            string chave,
            PacoteExame prototipo)
        {
            _prototipos[chave] = prototipo;
        }

        public PacoteExame? ObterClone(
            string chave)
        {
            if (_prototipos.TryGetValue(
                chave,
                out PacoteExame? prototipo))
            {
                // Usa a interface genérica.
                return prototipo.Clonar();
            }

            return null;
        }
    }
}
