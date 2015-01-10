package com.aleks.server.net;

import com.aleks.server.net.model.player.Account;
import org.jboss.netty.channel.ChannelHandlerContext;
import org.jboss.netty.channel.ChannelStateEvent;
import org.jboss.netty.channel.ExceptionEvent;
import org.jboss.netty.channel.SimpleChannelHandler;
import org.jboss.netty.handler.timeout.ReadTimeoutException;

/**
 * Created by Aleksandr on 10/1/2015.
 */
public class ChannelHandler extends SimpleChannelHandler
{

    @Override
    public void exceptionCaught(ChannelHandlerContext ctx, ExceptionEvent e) throws Exception
    {
        if (e.getCause() instanceof ReadTimeoutException)
        {
            if (ctx.getChannel() !=null)
            {
                Account account = Account.getAccountByChannel(ctx.getChannel());
                if (account != null)
                {
                    account.disconnect();
                }
            }
        }
    }

    @Override
    public void channelClosed(ChannelHandlerContext ctx, ChannelStateEvent e) throws Exception
    {
        if (ctx.getChannel() !=null)
        {
            Account account = Account.getAccountByChannel(ctx.getChannel());
            if (account != null)
            {
                account.disconnect();
            }
        }
    }
}
