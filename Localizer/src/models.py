from typing import TypeAlias

from msgspec import Struct

Guid: TypeAlias = str


class LocalizedString(Struct):
    Key: Guid
    SimpleName: str
    ProcessTemplates: bool
    enGB: str | None
    ruRU: str | None
    deDE: str | None
    frFR: str | None
    zhCN: str | None
    esES: str | None


class LocalisationPack(Struct):
    LocalizedStrings: list[LocalizedString]
