package com.aleks.server.net.packets.impl;


import com.aleks.server.net.model.player.Account;
import com.aleks.server.net.model.player.TempChar;
import com.aleks.server.net.packets.Packet;
import com.aleks.server.net.packets.PacketOpcodeHeader;
import com.aleks.server.util.MySQL;
import org.jboss.netty.buffer.ChannelBuffer;
import org.jboss.netty.buffer.ChannelBufferInputStream;

import java.io.IOException;
import java.sql.ResultSet;
import java.sql.SQLClientInfoException;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

@PacketOpcodeHeader({1})
public class CharacterRequestPacket extends Packet
{

    @Override
    public void decode(Account account, ChannelBuffer buffer)
    {
        ResultSet results = MySQL.getCharacters(account);
        List<TempChar> characters = new ArrayList<TempChar>();
        try
        {
            while (results.next())
            {
             //   String name = results.getString(3);evxytujrmy dane z bazy kolumnowo
            characters.add(new TempChar());
            }
        }
        catch(SQLException e)
        {
            e.printStackTrace();
        }
        // if account has no characters
        if (characters.isEmpty())
        {
        account.getPacketBuilder().sendCharacters();
        }
        else
        {
        account.getPacketBuilder().sendCharacters(characters);
        }
    }



}
