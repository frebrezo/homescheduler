package org.wonkim.homescheduler.dto;

public class PostResponseDto<T> {
    private T data = null;
    private int changeCount = 0;

    public PostResponseDto(T data, int changeCount) {
        this.data = data;
        this.changeCount = changeCount;
    }

    public PostResponseDto() { }

    public T getData() {
        return data;
    }

    public void setData(T data) {
        this.data = data;
    }

    public int getChangeCount() {
        return changeCount;
    }

    public void setChangeCount(int changeCount) {
        this.changeCount = changeCount;
    }
}
