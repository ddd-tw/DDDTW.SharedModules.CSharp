namespace DDDTW.SharedModules.Interfaces
{
    public interface ITranslator<Tdm, Trm>
    {
        Tdm Translate(Trm input);

        Trm TranslateReverse(Tdm output);
    }
}