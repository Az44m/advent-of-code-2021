using TextCopy;

namespace AdventOfCode2021 {
    public class ClipboardUtils {
        private readonly Clipboard _clipboard;

        public ClipboardUtils() => _clipboard = new Clipboard();

        public void CopyToClipBoard(object obj) {
            _clipboard.SetText($"{obj}");
        }

    }
}