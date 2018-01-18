public interface IGroundedController
{
	
    event System.Action HitGround;
    event System.Action LeaveGround;

    bool Grounded { get; }

}
