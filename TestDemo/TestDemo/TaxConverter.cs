namespace TestDemo
{
    public static class TaxConverter
    {
        public static double GrossFromNet(double net, double vatRate)
        {
            return net + vatRate / 100 * net;
        }

        public static double NetFromGross(double gross, double vatRate)
        {
            return gross / (1 + vatRate / 100);
        }
    }
}
