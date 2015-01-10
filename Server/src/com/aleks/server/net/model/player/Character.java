package com.aleks.server.net.model.player;


import com.aleks.server.util.Position;

public class Character
{
    String playerName;
    //other things
    private Position position;

    public Character(String name)
    {}

    public Position getPosition()
    {
        return position;
    }
}
