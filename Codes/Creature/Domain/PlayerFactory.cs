using ShengChao.Codes.Core.Config;

namespace ShengChao.Codes.Player.Domain;

public class PlayerFactory
{
   public Player createPlayer()
    {
        var playerScene = ScenesConfig.create(ScenesConfig.Scennes.Player);
        return playerScene.Instantiate<Player>();
    }
}