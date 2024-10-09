namespace ClassLibrary;

//Esta clase conoce las especificaciones del turno de un jugador actual con sus correspondientes ataques 

public class Turn
{
    public bool SpecialMoveIsAvailable { get; set; }

    public Turn()
    {
        this.SpecialMoveIsAvailable = true;
    }

}