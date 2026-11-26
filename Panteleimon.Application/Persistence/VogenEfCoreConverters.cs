using Panteleimon.Domain.Owners;
using Vogen;

namespace Panteleimon.Application.Persistence;

// One line per id type.
[EfCoreConverter<OwnerId>]
internal partial class VogenEfCoreConverters;