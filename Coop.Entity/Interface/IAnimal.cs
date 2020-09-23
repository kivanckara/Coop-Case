namespace Coop.Entity.Interface
{
    public interface IAnimal
    {
        public bool IsReadyForPregnancy();

        public bool IsPregnant();

        public int NewBornMaleCount();

        public int NewBornFemaleCount();
    }
}