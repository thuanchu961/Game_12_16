using System.ComponentModel;
public class Constant 
{
    public enum CAR
    {
        PinkCar,
        OrangeCar,
        BlueCar
    }
    public enum CAR_OPTION
    {
        Option1,
        Option2,
        Option3,
    }
    public enum MUSIC
    {
        PlayGame,
        WaittingSelectedCar
    }
    public enum SOUND
    {
        GreatChoice,
        CrowdCheering,
        StadiumCrowdCheering,
        ItemTouch,
        EnergyTouch,
        CountDown,
        CrowdDisappoint,
        EnergyPowerUp,
        Guiding,
        Intro,
        NiceDriving,
        m,
        a,
        t,
        mat,
    }
    public enum TAG
    {
        Audience,
        AddForce,
        Alphabet
    }
    public enum OrangeCar
    {
        [Description("Xe cam_0")]
        Start,
        [Description("Xe cam_1")]
        Move,
        [Description("Xe cam_2")]
        Fadein,
        [Description("Xe cam_2-1")]
        Flicker,
        [Description("Xe cam_1-3")]
        AddForce1,
        [Description("Xe cam_3")]
        AddForce2,
    }
    public enum PinkCar
    {
        [Description("Xe hong_0")]
        Start,
        [Description("Xe hong_1")]
        Move,
        [Description("Xe hong_2")]
        Fadein,
        [Description("Xe hong_2-1")]
        Flicker,
        [Description("Xe hong_1-3")]
        AddForce1,
        [Description("Xe hong_3")]
        AddForce2,
    }
    public enum BlueCar
    {
        [Description("Xe xanh_0")]
        Start,
        [Description("Xe xanh_1")]
        Move,
        [Description("Xe xanh_2")]
        Fadein,
        [Description("Xe xanh_2-1")]
        Flicker,
        [Description("Xe xanh_1-3")]
        AddForce1,
        [Description("Xe xanh_3")]
        AddForce2,
    }
    public enum Referee
    {
        [Description("Referee - Idle")]
        Idle,
        [Description("Referee - Go")]
        Go,
        [Description("Referee - Happy - 100%")]
        Happy,
    }
}
