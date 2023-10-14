package org.wonkim.homescheduler.dto;

public class NoDataRequestDto {
    public NoDataRequestDto() { }

    public NoDataRequestDto(String updatedBy)
    {
        this.updatedBy = updatedBy;
    }

    private String updatedBy;

    public String getUpdatedBy() {
        return updatedBy;
    }

    public void setUpdatedBy(String updatedBy) {
        this.updatedBy = updatedBy;
    }
}
