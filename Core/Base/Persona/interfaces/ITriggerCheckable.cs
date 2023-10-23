namespace Test.Monster.domain.interfaces;

public interface ITriggerCheckable
{
    bool IsHatred { get; set; }

    bool IsWithinStrikingDistance { get; set; }

    void SetHatredStatue(bool isHatred);

    void SetStrikingDistance(bool isWithinStrikingDistance);
}