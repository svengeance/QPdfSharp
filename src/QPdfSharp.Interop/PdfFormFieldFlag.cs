namespace QPdf.Interop;

[NativeTypeName("unsigned int")]
public enum PdfFormFieldFlag : uint
{
    ff_all_read_only = 1 << 0,
    ff_all_required = 1 << 1,
    ff_all_no_export = 1 << 2,
    ff_btn_no_toggle_off = 1 << 14,
    ff_btn_radio = 1 << 15,
    ff_btn_pushbutton = 1 << 16,
    ff_btn_radios_in_unison = 1 << 17,
    ff_tx_multiline = 1 << 12,
    ff_tx_password = 1 << 13,
    ff_tx_file_select = 1 << 20,
    ff_tx_do_not_spell_check = 1 << 22,
    ff_tx_do_not_scroll = 1 << 23,
    ff_tx_comb = 1 << 24,
    ff_tx_rich_text = 1 << 25,
    ff_ch_combo = 1 << 17,
    ff_ch_edit = 1 << 18,
    ff_ch_sort = 1 << 19,
    ff_ch_multi_select = 1 << 21,
    ff_ch_do_not_spell_check = 1 << 22,
    ff_ch_commit_on_sel_change = 1 << 26,
}
