using Turbo.Plugins.Default;
namespace Turbo.Plugins.glq
{
    public class GLQ_PartyBuffConfigPlugin : BasePlugin, ICustomizer
	{
        public GLQ_PartyBuffConfigPlugin()
		{
            Enabled = true;
		}
        public void Customize()
        {
 
Hud.RunOnPlugin<GLQ_PartyBuffPlugin>(plugin => 
{ 
    uint[] onWiz = {
		//onWiz
        

	}; 
    uint[] onMonk = {
		//onMonk

	}; 
    uint[] onWD = {
		//onWD
        
	}; 
    uint[] onBarb = {
		//onBarb
		
	}; 
    uint[] onCrus = {
		//onCrus
        
	}; 
    uint[] onDH = {
		//onDH
        
		383014,

		446187,
	}; 
    uint[] onAll = {
		//onAll
		430674,
		134872,
		440569,
		429855,
		450294,
		359580,
		445814,
		429673,
		437711,
		439308,
		436426,
		445829,
		445639,
		409428,
		434964,
		423244,
		428348,
		403471,
		428030,
		403464,
		383014,

	}; 
    uint[] onMe = {
		//onMe

		403460,
	};  
    //pass buffs to plugin -> apply them 
    plugin.DisplayOnAll(onAll); 
    plugin.DisplayOnMe(onMe); 
    plugin.DisplayOnClassExceptMe(HeroClass.Wizard, onWiz); 
    plugin.DisplayOnClassExceptMe(HeroClass.Monk, onMonk); 
    plugin.DisplayOnClassExceptMe(HeroClass.Barbarian, onBarb); 
    plugin.DisplayOnClassExceptMe(HeroClass.WitchDoctor, onWD); 
    plugin.DisplayOnClassExceptMe(HeroClass.DemonHunter, onDH); 
    plugin.DisplayOnClassExceptMe(HeroClass.Crusader, onCrus); 
            }); 
        }
    }
}