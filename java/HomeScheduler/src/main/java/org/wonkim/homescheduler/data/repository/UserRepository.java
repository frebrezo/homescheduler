package org.wonkim.homescheduler.data.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.wonkim.homescheduler.data.entity.User;

public interface UserRepository extends JpaRepository<User, Integer> {
}
