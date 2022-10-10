namespace SistemaEstacionamento;
public class Estacionamento
{
    public decimal PrecoInicial { get; }
    public decimal PrecoPorHora { get; }
    
    public Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
        this.PrecoInicial = precoInicial;
        this.PrecoPorHora = precoPorHora;
    }
    public List<Veículos> listaVeiculos = new List<Veículos>();
    public bool check;
    public bool VeiculoEstacionado(string entrada)
    {
        foreach (Veículos v in listaVeiculos)
        {
            string placaCheck = v.Placa;
            if (placaCheck == entrada)
            {
                check = true;
                listaVeiculos.Remove(v);
                return check;
            }
            else
            {
                check = false;
            }
        }
        return check;
    }
}
