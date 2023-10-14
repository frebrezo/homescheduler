package org.wonkim.homescheduler.dto;

public class UpdateResponseDto<T> {
    private T data = null;
    private int changeCount = 0;

    public UpdateResponseDto(T data, int changeCount) {
        this.data = data;
        this.changeCount = changeCount;
    }

    public UpdateResponseDto() { }

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
