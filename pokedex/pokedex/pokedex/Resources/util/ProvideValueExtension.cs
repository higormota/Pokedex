using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pokedex.Resources.util
{
    /*  -------------------------------------------------------------------
     * |Interface usada para permitir que propriedades de algum objeto XAML |
     * |recebam valores fora do padrão. Neste caso,  a propriedade Source da| 
     * |Image deve aceitar imagens embutidas (embedded) via Xaml.           |
     *  ------------------------------------------------------------------- */

    [ContentProperty("Source")]
    class ProvideValueExtension : IMarkupExtension
    {
        
            public string Source { get; set; } //Criação da Propriedade Source

            //Classe que retorna um objeto genérico. 
            public object ProvideValue(IServiceProvider serviceProvider)
            {
                if (Source == null)
                {
                    return null;
                }

            //Recupera o texto da propriedade Source e, com base no caminho informado, atribui o tipo FromResource ao retorno, necessário para o carregamento da imagem embutida.
                var imageSource = ImageSource.FromResource(Source); 
                return imageSource;
            }
    }
    
}
