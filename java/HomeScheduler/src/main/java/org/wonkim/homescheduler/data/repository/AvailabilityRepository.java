package org.wonkim.homescheduler.data.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.wonkim.homescheduler.data.entity.Availability;

import java.util.Optional;

public interface AvailabilityRepository extends JpaRepository<Availability, Integer> {
    Optional<Availability> findByUserId(int userId);
}
