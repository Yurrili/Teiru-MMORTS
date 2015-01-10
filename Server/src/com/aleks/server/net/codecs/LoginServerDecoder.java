package com.aleks.server.net.codecs;

import com.aleks.server.net.model.player.Account;
import com.aleks.server.util.MySQL;
import org.jboss.netty.buffer.ChannelBuffer;
import org.jboss.netty.buffer.ChannelBufferInputStream;
import org.jboss.netty.channel.Channel;
import org.jboss.netty.channel.ChannelHandlerContext;
import org.jboss.netty.handler.codec.frame.FrameDecoder;


public class LoginServerDecoder extends FrameDecoder
{
    @Override
    protected Object decode(ChannelHandlerContext ctx, Channel channel, ChannelBuffer buffer) throws Exception
    {
        ChannelBufferInputStream in = new ChannelBufferInputStream(buffer);

        // TODO :Login
        String username =in.readUTF();
        String password =in.readUTF();

        //TODO: Sql Login Check
        //if true create account
        //Remove LoginServerDecoder , Set up GameServerDecoder
        //return the account
        if (MySQL.Login(username,password))
        {
            Account account = new Account(channel, username);
            ctx.getPipeline().remove("decoder");//remove login server
            channel.getPipeline().addFirst("decoder", new GameServerDecoder());//start game server
            in.close();
            return  account;
        }
        else
        {
        // TODO Sena a packet that login was invalid
            PacketEncoder failedEncoder = new PacketEncoder(channel);
            failedEncoder.sendLogin(false,null,(byte)0);
            System.err.println("Player attempted login with invalid information");
        }
        in.close();
        return null;
    }
}
