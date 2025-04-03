# CounterstrikeSharp - Chat Info

[![UpdateManager Compatible](https://img.shields.io/badge/CS2-UpdateManager-darkgreen)](https://github.com/Kandru/cs2-update-manager/)
[![GitHub release](https://img.shields.io/github/release/Kandru/cs2-chat-info?include_prereleases=&sort=semver&color=blue)](https://github.com/Kandru/cs2-chat-info/releases/)
[![License](https://img.shields.io/badge/License-GPLv3-blue)](#license)
[![issues - cs2-map-modifier](https://img.shields.io/github/issues/Kandru/cs2-chat-info)](https://github.com/Kandru/cs2-chat-info/issues)
[![](https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/donate/?hosted_button_id=C2AVYKGVP9TRG)

Define !info command entries a player will see when typing in !info. This allows for example to list rules, other commands, etc.

## Installation

1. Download and extract the latest release from the [GitHub releases page](https://github.com/Kandru/cs2-chat-info/releases/).
2. Move the "ChatInfo" folder to the `/addons/counterstrikesharp/plugins/` directory.
3. Restart the server.

Updating is even easier: simply overwrite all plugin files and they will be reloaded automatically. To automate updates please use our [CS2 Update Manager](https://github.com/Kandru/cs2-update-manager/).


## Configuration

This plugin automatically creates a readable JSON configuration file. This configuration file can be found in `/addons/counterstrikesharp/configs/plugins/ChatInfo/ChatInfo.json`.

```json
{
  "enabled": true,
  "debug": false,
  "messages": {
    "-\u003E Discord": {
      "description": {
        "en": "visit https://counterstrike.party",
        "de": "besuche https://counterstrike.party"
      },
      "sub_commands": {}
    },
    "!as": {
      "description": {
        "en": "Airstrike Status",
        "de": "Status Luftunterst\u00FCtzung"
      },
      "sub_commands": {}
    },
    "!c": {
      "description": {
        "en": "Toggles the Challenge Overview",
        "de": "Challenge-\u00DCbersicht ein/aus"
      },
      "sub_commands": {}
    },
    "!cl \u003Cmapname\u003E": {
      "description": {
        "en": "Vote to change to a specific map",
        "de": "Voting f\u00FCr eine bestimmte Karte"
      },
      "sub_commands": {}
    },
    "!nom \u003Cmapname\u003E": {
      "description": {
        "en": "Nominate a map for voting",
        "de": "Nominiere eine Karte f\u00FCrs Voting"
      },
      "sub_commands": {}
    },
    "!noms": {
      "description": {
        "en": "Lists all nominations so far",
        "de": "Listet alle aktuellen Nominierungen"
      },
      "sub_commands": {}
    },
    "!rtd": {
      "description": {
        "en": "Roll The Dice",
        "de": "W\u00FCrfeln"
      },
      "sub_commands": {
        "auto": {
          "description": {
            "en": "Roll The Dice automatically",
            "de": "Automatisch w\u00FCrfeln"
          },
          "sub_commands": {}
        }
      }
    },
    "!rtv": {
      "description": {
        "en": "Rock The Vote",
        "de": "Rock The Vote"
      },
      "sub_commands": {}
    },
    "!top": {
      "description": {
        "en": "Lists players with best rankings",
        "de": "Spieler mit den h\u00F6chsten R\u00E4ngen"
      },
      "sub_commands": {}
    },
    "!topc": {
      "description": {
        "en": "Lists players with most solved Challenges",
        "de": "Spieler mit den meisten Herausforderungen"
      },
      "sub_commands": {}
    }
  },
  "ConfigVersion": 1
}
```

## Commands

Commands players can use to invoke the chat info:

- !?
- !commands
- !help
- !info


## Compile Yourself

Clone the project:

```bash
git clone https://github.com/Kandru/cs2-chat-info.git
```

Go to the project directory

```bash
  cd cs2-chat-info
```

Install dependencies

```bash
  dotnet restore
```

Build debug files (to use on a development game server)

```bash
  dotnet build
```

Build release files (to use on a production game server)

```bash
  dotnet publish
```

## FAQ

TODO

## License

Released under [GPLv3](/LICENSE) by [@Kandru](https://github.com/Kandru).

## Authors

- [@derkalle4](https://www.github.com/derkalle4)
- [@jmgraeffe](https://www.github.com/jmgraeffe)
