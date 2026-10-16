///|/ Copyright (c) 2026 Cherry3D
///|/
///|/ PrusaSlicer is released under the terms of the AGPLv3 or higher
///|/
#ifndef slic3r_SolaPrint_hpp_
#define slic3r_SolaPrint_hpp_

#include <string>
#include <wx/string.h>

#include "OctoPrint.hpp"
#include "libslic3r/PrintConfig.hpp"


namespace Slic3r {

class DynamicPrintConfig;
class Http;

// SolaPrint is a WiFi module for the Cherry3D printer board.
// It exposes an OctoPrint-compatible HTTP API, so it is implemented
// as a thin subclass of OctoPrint.
class SolaPrint : public OctoPrint
{
public:
    SolaPrint(DynamicPrintConfig *config);
    ~SolaPrint() override = default;

    const char* get_name() const override;

    wxString get_test_ok_msg () const override;
    wxString get_test_failed_msg (wxString &msg) const override;
};

}

#endif