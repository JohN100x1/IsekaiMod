from pathlib import Path

from msgspec.json import decode

from models import LocalisationPack

path_localization_pack = (
    Path(__file__).parent.parent / "data" / "LocalizationPack.json"
)


def load_localization_pack(path_pack: Path):
    with open(path_pack, "rb") as f:
        return decode(f.read(), type=LocalisationPack)
