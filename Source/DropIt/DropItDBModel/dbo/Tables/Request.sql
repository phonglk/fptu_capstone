CREATE TABLE [dbo].[Request] (
    [UserId]       INT            NOT NULL,
    [EventId]      INT            NOT NULL,
    [Status]       INT            NOT NULL,
    [Description]  NVARCHAR (MAX) NULL,
    [CreatedDate]  DATETIME       NULL,
    [ModifiedDate] DATETIME       NULL,
    CONSTRAINT [PK_Request_1] PRIMARY KEY CLUSTERED ([UserId] ASC, [EventId] ASC),
    CONSTRAINT [FK_Request_Event] FOREIGN KEY ([EventId]) REFERENCES [dbo].[Event] ([EventId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Request_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]) ON DELETE CASCADE ON UPDATE CASCADE
);








GO
CREATE TRIGGER [dbo].[Update_Status_Delete_Request]
	ON [dbo].[Request]
	After UPDATE
	AS
	BEGIN
		SET NOCOUNT ON
		if not update([Status])
		Return

		if exists(select * from inserted where [Status] = 1)
		begin 
			delete from TicketResponse
			where [EventId] IN (select EventId from inserted where [Status] = 1)
			and  UserId IN (select UserId from inserted where [Status] = 1)

			delete from Request
			where [EventId] IN (select EventId from inserted where [Status] = 1)
			and [UserId] IN (select UserId from inserted where [Status] = 1)
		end

	END