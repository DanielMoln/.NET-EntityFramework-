namespace NetRelations.DTOs
{
    public record struct CharacterCreateDto(string Name,
        BackpackCreateDto BackpackCreate,
        List<WeaponCreateDto> weapons);
}
