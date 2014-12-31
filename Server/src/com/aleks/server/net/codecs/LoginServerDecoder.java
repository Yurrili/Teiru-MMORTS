package com.aleks.server.net.codecs;

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
        return null;
    }
}
