package com.aleks.server.net.codecs;


import com.aleks.server.net.model.player.*;
import com.aleks.server.net.packets.impl.CharacterRequestPacket;
import org.jboss.netty.buffer.ChannelBuffer;
import org.jboss.netty.buffer.ChannelBufferInputStream;
import org.jboss.netty.buffer.ChannelBufferOutputStream;
import org.jboss.netty.buffer.DynamicChannelBuffer;
import org.jboss.netty.channel.Channel;

import java.io.IOException;
import java.util.List;

public class PacketEncoder
{
    private Account account;
    private Channel channel;


    public PacketEncoder(Account account)
    {
       this.account = account;
    }

    public PacketEncoder(Channel channel)
    {
        this.channel = channel;
    }

    public PacketEncoder SendCharacterLoadResult(boolean success, com.aleks.server.net.model.player.Character character)
    {

        return this;
    }

    //tell the client is character name already exists
    //tell if the ccharacter is created succesfuly
    public PacketEncoder SendCharacterCreationResult(boolean exists,boolean success)
    {
        ChannelBuffer buffer = new DynamicChannelBuffer(2);
        ChannelBufferOutputStream out = new ChannelBufferOutputStream(buffer);
     try
    {
   out.writeBoolean(exists);
        out.writeBoolean(success);
        send(out.buffer());
        out.close();
    }
    catch(IOException e)
    {
        e.printStackTrace();
    }
        return this;


    }



    //list of the characters available for the user
    public PacketEncoder sendCharacters(List<TempChar> characters)
    {
        ChannelBuffer buffer = new DynamicChannelBuffer(2);
        ChannelBufferOutputStream out = new ChannelBufferOutputStream(buffer);
        try
        {
            out.writeBoolean(true);
            out.writeInt(characters.size());// tell user how many characters he has
            for (TempChar character : characters)
            {//send information about characs
                out.writeByte((byte)0);
               // out.writeUTF(character.characterName);
               // out.writeInt(character.level);
                out.writeByte((byte)1);
            }
           send(out.buffer());
            out.close();
        }
        catch(IOException e)
        {
            e.printStackTrace();
        }
        return this;
    }
    //tell the client that there are no account available
    public PacketEncoder sendCharacters()
    {
        ChannelBuffer buffer = new DynamicChannelBuffer(2);
        ChannelBufferOutputStream out = new ChannelBufferOutputStream(buffer);
        try
        {
            out.writeBoolean(false);
            send(out.buffer());
            out.close();
        }
        catch(IOException e)
        {
            e.printStackTrace();
        }
        return this;
    }

    public PacketEncoder sendLogin(Boolean value , Account account,byte opcode)
    {
        ChannelBuffer buffer = new DynamicChannelBuffer(2);
        ChannelBufferOutputStream out = new ChannelBufferOutputStream(buffer);
        try
        {
            out.writeInt(0);
            out.writeBoolean(value);
            if(value)
            {
                out.writeUTF(account.getUsername());
            }
            if(!value)
            {
                out.writeByte(opcode);
            }
            send(out.buffer());
            out.close();
        }
        catch(IOException e)
        {
            e.printStackTrace();
        }
        return this;
    }

    public void send(ChannelBuffer buffer)
    {
        if (account == null)
        {
            channel.write(buffer);
            return;
        }

        if(account.getChannel() == null || !account.getChannel().isConnected())
        {
            System.err.println("Channel null OR Connection null");
            return;
        }
        account.getChannel().write(buffer);
    }
}
