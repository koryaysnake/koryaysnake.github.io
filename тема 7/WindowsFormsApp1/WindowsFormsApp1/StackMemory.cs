using System;
using System.Collections.Generic;
using System.IO;

[Serializable]
public class StackMemory
{
    readonly int _depth;
    readonly List<byte[]> _list = new List<byte[]>();

    public StackMemory(int depth)
    {
        _depth = depth;
    }

    public void Push(MemoryStream stream)
    {
        if (_list.Count >= _depth)
            _list.RemoveAt(0);

        _list.Add(stream.ToArray());
    }

    public void Pop(MemoryStream stream)
    {
        if (_list.Count == 0) return;

        var data = _list[_list.Count - 1];
        stream.Write(data, 0, data.Length);
        _list.RemoveAt(_list.Count - 1);
    }
}
