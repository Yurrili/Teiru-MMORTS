package com.aleks.server.net.packets.impl;

import com.aleks.server.net.model.player.Account;
import com.aleks.server.net.packets.Packet;
import com.aleks.server.net.packets.PacketOpcodeHeader;
import org.jboss.netty.buffer.ChannelBuffer;
import org.jboss.netty.buffer.ChannelBufferInputStream;

import java.io.IOException;

@PacketOpcodeHeader({3})
public class CharacterLoadPacket extends Packet
{
    @Override
    public void decode(Account account, ChannelBuffer buffer)
    {
        try
        {
            ChannelBufferInputStream in = new ChannelBufferInputStream(buffer);
            String CharacterName = in.readUTF();
            //TODO loadcharacter by name


            in.close();
        }
        catch(IOException e)
        {
e.printStackTrace();
        }
    }
}
