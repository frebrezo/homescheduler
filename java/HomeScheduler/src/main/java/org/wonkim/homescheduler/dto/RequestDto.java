package org.wonkim.homescheduler.dto;

public class RequestDto<T> {
    private T data = null;
    private String updatedBy;

    public T getData() { return data; }
    public void setData(T data) { this.data = data; }

    public String getUpdatedBy() { return updatedBy; }
    public void setUpdatedBy(String updatedBy) { this.updatedBy = updatedBy; }
}
