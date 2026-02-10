namespace RestWithASPNET10.Data.Converter.Contract.Interface
{
    public interface IParser<O, D>
    {
        D Parse(O origin);
        List<D> ParseList(List<O> origin);
	}
}
