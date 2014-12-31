package com.aleks.server.net.codecs;


import com.aleks.server.net.model.player.Account;
import com.aleks.server.net.packets.Packet;
import org.jboss.netty.buffer.ChannelBuffer;
import org.jboss.netty.buffer.ChannelBufferInputStream;
import org.jboss.netty.channel.Channel;
import org.jboss.netty.channel.ChannelHandlerContext;
import org.jboss.netty.handler.codec.frame.FrameDecoder;

public class GameServerDecoder extends FrameDecoder
{
    @Override
    protected Object decode(ChannelHandlerContext ctx, Channel channel, ChannelBuffer buffer) throws Exception
    {
        ChannelBufferInputStream in = new ChannelBufferInputStream(buffer);
        int packetOpCode = in.readByte();
        Account account = Account.getAccountByChannel(channel);
        if (account == null)
        {
            System.err.println("ERROR: [GameServerDecoder] Triend to handle data for a null account");
            return null;
        }

        if (Packet.getPackets()[packetOpCode] != null)
        {
            Packet.getPackets()[packetOpCode].decode(account, buffer);

        }
        else
        {
            System.out.println("[Undefined packet]: Error, Packet with the ID of ["+packetOpCode+"] was received but nit handled");
            return null;
        }
        return null;
    }
}
