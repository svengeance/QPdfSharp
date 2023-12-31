namespace QPdfSharp.Enums;

public enum PdfFormFieldFlag : uint
{
    AllReadOnly = 1 << 0,
    AllRequired = 1 << 1,
    AllNoExport = 1 << 2,
    ButtonNoToggleOff = 1 << 14,
    ButtonRadio = 1 << 15,
    ButtonPushbutton = 1 << 16,
    ButtonRadiosInUnison = 1 << 17,
    TextMultiline = 1 << 12,
    TextPassword = 1 << 13,
    TextFileSelect = 1 << 20,
    TextDoNotSpellCheck = 1 << 22,
    TextDoNotScroll = 1 << 23,
    TextComb = 1 << 24,
    TextRichText = 1 << 25,
    ChooseCombo = 1 << 17,
    ChooseEdit = 1 << 18,
    ChooseSort = 1 << 19,
    ChooseMultiSelect = 1 << 21,
    ChooseDoNotSpellCheck = 1 << 22,
    ChooseCommitOnSelChange = 1 << 26,
}
