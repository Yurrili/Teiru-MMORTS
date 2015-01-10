package com.aleks.server.net.model.player;


import com.aleks.server.net.codecs.PacketEncoder;
import org.jboss.netty.channel.Channel;

import java.util.ArrayList;
import java.util.List;

public class Account // just holding username
{
    private final Channel channel;

    private PacketEncoder packetBuilder;
    private String username;

    public Account(Channel channel, String username)
    {
        this.channel = channel;
        this.username = username;
        packetBuilder = new PacketEncoder(this);
        login(username);
    }

    public void logOut()
    {

    }

    public void disconnect()
    {OnlineAccounts.remove(this);
    channel.close();
    }


    public void login(String username)
    {
        if (getAccountByUsername(getUsername())!=null)
        {
            getPacketBuilder().sendLogin(false, null,(byte)1);
        return ;
        }
        OnlineAccounts.add(this);
        getPacketBuilder().sendLogin(true, this,(byte)-1);
    }

    public Channel getChannel()
    {
        return channel;
    }

    public String getUsername()
    {
        return username;
    }

    public PacketEncoder getPacketBuilder()
    {
        return packetBuilder;
    }

    public static List<Account> OnlineAccounts = new ArrayList<Account>();

    public static Account getAccountByUsername(String username)
    {
        for (Account account : OnlineAccounts)
        {
            if (account.getUsername().equals(username))
            {
                return account;
            }
        }

        return null;
    }

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
