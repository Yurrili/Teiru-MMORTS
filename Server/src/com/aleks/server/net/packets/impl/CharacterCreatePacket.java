package com.aleks.server.net.packets.impl;

import com.aleks.server.net.model.player.Account;
import com.aleks.server.net.packets.Packet;
import com.aleks.server.net.packets.PacketOpcodeHeader;
import com.aleks.server.util.MySQL;
import org.jboss.netty.buffer.ChannelBuffer;
import org.jboss.netty.buffer.ChannelBufferInputStream;

import java.io.IOException;

@PacketOpcodeHeader({2})
public class CharacterCreatePacket extends Packet
{
    @Override
    public void decode(Account account, ChannelBuffer buffer)
    {
        try
        {
            ChannelBufferInputStream in = new ChannelBufferInputStream(buffer);
            //inf about character
            String name = in.readUTF();
            if(MySQL.CharachetExists(name))
            {
            //TODO TEll client no
            }
            else
            {

            }

            in.close();
        }
        catch(IOException e)
        {
            e.printStackTrace();
        }
    }
}
