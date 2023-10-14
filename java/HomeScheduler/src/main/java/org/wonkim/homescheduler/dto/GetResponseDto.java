package org.wonkim.homescheduler.dto;

import java.util.List;

public class GetResponseDto<T> {
    public GetResponseDto() { }

    public GetResponseDto(List<T> data, int pageSize)
    {
        this.data = data;
        this.count = data.size();
        this.pageSize = pageSize;
    }

    public GetResponseDto(List<T> data)
    {
        this.data = data;
        this.count = data.size();
        this.pageSize = data.size();
    }

    private List<T> data = null;
    private int count = 0;
    private int pageSize;

    public List<T> getData() {
        return data;
    }

    public void setData(List<T> data) {
        this.data = data;
    }

    public int getCount() {
        return count;
    }

    public void setCount(int count) {
        this.count = count;
    }

    public int getPageSize() {
        return pageSize;
    }

    public void setPageSize(int pageSize) {
        this.pageSize = pageSize;
    }
}
