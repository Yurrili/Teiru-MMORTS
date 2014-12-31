package com.aleks.server.net.packets;

import com.aleks.server.net.model.player.Account;
import org.jboss.netty.buffer.ChannelBuffer;

@PacketOpcodeHeader({1})
public abstract class Packet
{
    public static Packet[] packets = new Packet[0];
    public abstract void decode(Account account,ChannelBuffer buffer);
    public static void addDecoder(Packet packet)
    {
        if (packet.getClass().getAnnotation(PacketOpcodeHeader.class)==null)
        {
        System.out.println("ERROR: ");System.err.print("Packet Opcode not found for " + packet + "\n");
        }
        int packetOpcodes[] = packet.getClass().getAnnotation(PacketOpcodeHeader.class).value();

        for(int opcode : packetOpcodes)
        {
            packets[opcode] = packet;
        }
    }

    public static Packet[] getPackets()
    {
        return packets;
    }

    public static void loadDecoders() throws Exception
    {
        //Packet.addDecoder((Packet)new PacketClass());
    }
}
