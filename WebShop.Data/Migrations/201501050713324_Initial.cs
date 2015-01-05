namespace WebShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            Sql(@"
            
            -- dbo.webpages_Membership
            CREATE TABLE [dbo].[webpages_Membership](
            	[UserId] [int] NOT NULL,
            	[CreateDate] [datetime] NULL,
            	[ConfirmationToken] [nvarchar](128) NULL,
            	[IsConfirmed] [bit] NULL,
            	[LastPasswordFailureDate] [datetime] NULL,
            	[PasswordFailuresSinceLastSuccess] [int] NOT NULL,
            	[Password] [nvarchar](128) NOT NULL,
            	[PasswordChangedDate] [datetime] NULL,
            	[PasswordSalt] [nvarchar](128) NOT NULL,
            	[PasswordVerificationToken] [nvarchar](128) NULL,
            	[PasswordVerificationTokenExpirationDate] [datetime] NULL,
            	PRIMARY KEY CLUSTERED 
            	(
            		[UserId] ASC
            	) ON [PRIMARY]
            )
            
            ALTER TABLE [dbo].[webpages_Membership] 
            	ADD DEFAULT ((0)) FOR [IsConfirmed]
            
            ALTER TABLE [dbo].[webpages_Membership] 
            	ADD DEFAULT ((0)) FOR [PasswordFailuresSinceLastSuccess]
            
            
            -- dbo.webpages_OAuthMembership
            CREATE TABLE [dbo].[webpages_OAuthMembership](
            	[Provider] [nvarchar](30) NOT NULL,
            	[ProviderUserId] [nvarchar](100) NOT NULL,
            	[UserId] [int] NOT NULL,
            	PRIMARY KEY CLUSTERED 
            	(
            		[Provider] ASC,
            		[ProviderUserId] ASC
            	) ON [PRIMARY]
            )
            
            
            -- dbo.webpages_Roles
            CREATE TABLE [dbo].[webpages_Roles](
            	[RoleId] [int] IDENTITY(1,1) NOT NULL,
            	[RoleName] [nvarchar](256) NOT NULL,
            	PRIMARY KEY CLUSTERED 
            	(
            		[RoleId] ASC
            	) ON [PRIMARY],
            	UNIQUE NONCLUSTERED 
            	(
            		[RoleName] ASC
            	)ON [PRIMARY]
            )
            
            
            -- dbo.webpages_UsersInRoles
            CREATE TABLE [dbo].[webpages_UsersInRoles](
            	[UserId] [int] NOT NULL,
            	[RoleId] [int] NOT NULL,
            	PRIMARY KEY CLUSTERED 
            	(
            		[UserId] ASC,
            		[RoleId] ASC
            	) ON [PRIMARY]
            )
            
            ALTER TABLE [dbo].[webpages_UsersInRoles] WITH CHECK 
            	ADD CONSTRAINT [fk_RoleId] FOREIGN KEY([RoleId])
            		REFERENCES [dbo].[webpages_Roles] ([RoleId])
            ALTER TABLE [dbo].[webpages_UsersInRoles] 
            	CHECK CONSTRAINT [fk_RoleId]

               ");


            Sql( @"

            ALTER TABLE [dbo].[webpages_UsersInRoles] WITH CHECK 
            	ADD CONSTRAINT [fk_UserId] FOREIGN KEY([UserId])
            		REFERENCES [dbo].[UserProfile] ([UserId])
            ALTER TABLE [dbo].[webpages_UsersInRoles] 
            	CHECK CONSTRAINT [fk_UserId]

               ");
        }

        public override void Down()
        {
            DropForeignKey("dbo.webpages_UsersInRoles", "fk_UserId");
            DropForeignKey("dbo.webpages_UsersInRoles", "fk_RoleId");
            DropTable("dbo.webpages_UsersInRoles");
            DropTable("dbo.webpages_Roles");
            DropTable("dbo.webpages_OAuthMembership");
            DropTable("dbo.webpages_Membership");

            DropTable("dbo.UserProfile");
        }
    }
}
