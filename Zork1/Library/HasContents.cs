namespace Zork1.Library;

public abstract class HasContents : Object
{
    protected HasContents()
    {
        Container = true;
    }

    public bool CanSeeContents => !Concealed && (Open || Transparent);

    public bool IsEmpty => Items.Count == 0;
}
