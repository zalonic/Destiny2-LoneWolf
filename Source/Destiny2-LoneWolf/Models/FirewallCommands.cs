//Sole Credit for FirewallCommands.cs belongs to the below GitHub user under the MIT License
//Name: Matthew Lee
//GitHub: https://github.com/fmmmlee
//Original Rep: https://github.com/fmmmlee/D2Solo

//MIT License

//Copyright (c) 2020 Matthew Lee

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

//Only changes I have made are cosmetic and the addition of port 3097

using System;
using NetFwTypeLib;

namespace Destiny2LoneWolf.Models
{
    internal static class FirewallCommands
    {
        private const string UdpOut = "Destiny 2 - Lone Wolf (UDP-Out)";
        private const string TcpOut = "Destiny 2 - Lone Wolf (TCP-Out)";
        private const string UdpIn = "Destiny 2 - Lone Wolf (UDP-In)";
        private const string TcpIn = "Destiny 2 - Lone Wolf (TCP-In)";

        internal static void CloseMatchmakingPorts()
        {
            //creating new rules
            INetFwRule2 outBoundUdp = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
            INetFwRule2 outBoundTcp = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
            INetFwRule2 inBoundUdp = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
            INetFwRule2 inBoundTcp = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));

            //names
            outBoundUdp.Name = UdpOut;
            outBoundTcp.Name = TcpOut;
            inBoundUdp.Name = UdpIn;
            inBoundTcp.Name = TcpIn;

            //enabling
            outBoundUdp.Enabled = true;
            outBoundTcp.Enabled = true;
            inBoundUdp.Enabled = true;
            inBoundTcp.Enabled = true;

            //specifying block as action
            outBoundUdp.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
            outBoundTcp.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
            inBoundUdp.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
            inBoundTcp.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;

            //setting UDP/TCP
            outBoundUdp.Protocol = 17;
            outBoundTcp.Protocol = 6;
            inBoundUdp.Protocol = 17;
            inBoundTcp.Protocol = 6;

            //specifying ports to block
            outBoundUdp.RemotePorts = "27000-27100,3097";
            outBoundTcp.RemotePorts = "27000-27100,3097";
            inBoundUdp.RemotePorts = "27000-27100,3097";
            inBoundTcp.RemotePorts = "27000-27100,3097";

            //direction
            outBoundUdp.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
            outBoundTcp.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
            inBoundUdp.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
            inBoundTcp.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;

            //fetching firewall policy
            INetFwPolicy2 currentFwPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));

            //adding new rules
            currentFwPolicy.Rules.Add(outBoundUdp);
            currentFwPolicy.Rules.Add(outBoundTcp);
            currentFwPolicy.Rules.Add(inBoundUdp);
            currentFwPolicy.Rules.Add(inBoundTcp);
        }

        internal static void OpenMatchmakingPorts()
        {
            //fetching firewall policy
            INetFwPolicy2 currentFwPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));

            //removing rules
            currentFwPolicy.Rules.Remove(UdpOut);
            currentFwPolicy.Rules.Remove(TcpOut);
            currentFwPolicy.Rules.Remove(UdpIn);
            currentFwPolicy.Rules.Remove(TcpIn);
        }
    }
}
