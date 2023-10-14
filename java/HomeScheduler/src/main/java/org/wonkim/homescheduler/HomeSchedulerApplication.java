package org.wonkim.homescheduler;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.scheduling.annotation.EnableAsync;

@EnableAsync
@SpringBootApplication
public class HomeSchedulerApplication {

	public static void main(String[] args) {
		SpringApplication.run(HomeSchedulerApplication.class, args);
	}

}
