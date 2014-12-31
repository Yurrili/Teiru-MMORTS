package com.aleks.server.net.model.player;


import org.jboss.netty.channel.Channel;

import java.util.ArrayList;
import java.util.List;

public class Account
{
    private final Channel channel;

    public Account(Channel channel)
    {
        this.channel = channel;
        login("text");
    }

    public void login(String username)
    {
        OnlineAccounts.add(this);
    }

    public Channel getChannel()
    {
        return channel;
    }

    public static List<Account> OnlineAccounts = new ArrayList<Account>();

    public static Account getAccountByChannel(Channel channel)
    {
        for (Account account : OnlineAccounts)
        {
            if (account.getChannel().equals(channel))
            {
                return account;
            }
        }
    return null;
    }
}
