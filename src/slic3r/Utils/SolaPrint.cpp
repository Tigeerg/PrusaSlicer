///|/ Copyright (c) 2026 Cherry3D
///|/
///|/ PrusaSlicer is released under the terms of the AGPLv3 or higher
///|/
#include "SolaPrint.hpp"

#include <string>

#include "slic3r/GUI/I18N.hpp"
#include "slic3r/GUI/format.hpp"

namespace Slic3r {

SolaPrint::SolaPrint(DynamicPrintConfig *config)
    : OctoPrint(config)
{}

const char* SolaPrint::get_name() const { return "SolaPrint"; }

wxString SolaPrint::get_test_ok_msg() const
{
    return _(L("Connection to SolaPrint works correctly."));
}

wxString SolaPrint::get_test_failed_msg(wxString &msg) const
{
    return GUI::format_wxstr("%s: %s\n\n%s"
        , _L("Could not connect to SolaPrint")
        , msg
        , _L("Note: SolaPrint requires an OctoPrint-compatible API."));
}

}
