namespace Strategy
{
    public class Ajuda
    {
        private IAjuda _ajuda;

        public Ajuda(IAjuda ajuda)
        {
            this._ajuda = ajuda;
        }

        public string Ajudar()
        {
            return this._ajuda.Ajudar(this);
        }
    }
}