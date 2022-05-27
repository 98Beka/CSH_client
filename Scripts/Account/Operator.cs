using System.Collections.Generic;

namespace CsharpPool.Assets.Scripts {
    public class Operator : Account {
        public string? Name { get; set; } = string.Empty;
        public int? Age { get; set; }
        public string? Telegram { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
    }
}